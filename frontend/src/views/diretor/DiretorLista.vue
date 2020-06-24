<template>
  <div class="list row">
    <div class="col-md-8">
      <div class="input-group mb-3">
        <input type="number" class="form-control" placeholder="Pesquisar por Id" 
          v-model="diretorId" min="1" autofocus 
        />
        <div class="input-group-append">
          <button class="btn btn-outline-secondary" type="button" @click="ObterDiretorPorId">Pesquisar</button>
        </div>
        <a href="/diretor/adicionar" class="nav-link">Adicionar Diretor</a>
      </div>
    </div>
    <div class="col-md-6">
      <h4>Diretores</h4>      
      <ul class="list-group">        
        <li class="list-group-item"
          :class="{ active: index == currentIndex }" v-for="(diretor, index) in diretores" :key="index"
          @click="setarDiretorAtivo(diretor, index)">                        
          {{ diretor.id }} - {{ diretor.nome }}
        </li>
      </ul>
    </div>
    <div class="col-md-6">
      <div v-if="diretorSelecionado">
        <h4>{{ diretorSelecionado.nome }}</h4>        
        <tr>
          <td>
            <button class="badge badge-warning mr-2" @click="editarDiretor()">Editar</button>
          </td> 
          <td>
            <button class="badge badge-danger mr-2" @click="deletarDiretor()">Deletar</button>
          </td>         
          <td>
            <button class="badge badge-secondary mr-2" @click="fecharDetalhe()">Fechar</button>
          </td>                     
        </tr>
        <br />        
        <h5>Filmes:</h5>  
        <ul>
          <li v-for="(filme, index) in filmes" :key="index">
            {{ filme.titulo }}          
          </li>
        </ul>
      </div>
      <div v-else>
        <br />
        <p v-if="diretores.length">Clique para ver informações do Diretor</p>
      </div>
    </div>
  </div>
</template>

<script>
import BaseService from "../../services/BaseService";

export default {
  name: "diretor-lista",
  data() {
    return {
      diretores: [],
      filmes: [],
      diretorSelecionado: null,
      currentIndex: -1,
      diretorId: "",
      endpoint: "/diretor",
      endpointFilme: "/filme"
    };
  },

  methods: {
    listarDiretores() {      
      BaseService.getAll(this.endpoint)
        .then(response => {     
          this.diretores = response.data.data;          
        })
        .catch(e => {
          console.log(e);
        });
    },

    listarFilmesPorDiretor(id) {      
      BaseService.get(this.endpoint + "/filmes", id)
        .then(response => {                    
          this.filmes = response.data.data;          
        })
        .catch(e => {
          console.log(e);
        });
    },

    atualizarListaDiretores() {
      this.listarDiretores();
      this.diretorSelecionado = null;
      this.currentIndex = -1;
    },

    setarDiretorAtivo(diretor, index) {
      this.diretorSelecionado = diretor;
      this.currentIndex = index;

      this.listarFilmesPorDiretor(diretor.id);
    },
    
    ObterDiretorPorId() {
      this.diretores = [];      
      this.filmes = [];
      this.diretorSelecionado = null;
      this.currentIndex = -1;

      BaseService.get(this.endpoint, this.diretorId)
        .then(response => {
          this.diretorSelecionado = response.data.data   
          
          if (this.diretorSelecionado != null) {
            this.diretores.push(this.diretorSelecionado);
            this.listarFilmesPorDiretor(this.diretorId);
          }          
        })
        .catch(e => {
          console.log(e);
        });
    },

    editarDiretor() {
      window.location.href = this.endpoint + '/detalhe/' + this.diretorSelecionado.id;
    },

    deletarDiretor() {      
      BaseService.delete(this.endpoint, this.diretorSelecionado.id)
        .then(response => {
          console.log(response.data);
          this.atualizarListaDiretores();
        })
        .catch(e => {
          console.log(e);
        });
    },
    
    fecharDetalhe() {
      this.diretorSelecionado = null;
      this.currentIndex = -1;
    },
  },
  mounted() {
    this.listarDiretores();    
  }
};
</script>

<style>
.list {
  text-align: left;
  max-width: 750px;
  margin: auto;
  }
</style>
