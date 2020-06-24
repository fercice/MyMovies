<template>
  <div class="list row">
    <div class="col-md-8">
      <div class="input-group mb-3">
        <input type="number" class="form-control" placeholder="Pesquisar por Id" v-model="filmeId" autofocus />
        <div class="input-group-append">
          <button class="btn btn-outline-secondary" type="button" @click="ObterFilmePorId">Pesquisar</button>
        </div>
        <a href="/filme/adicionar" class="nav-link">Adicionar Filme</a>
      </div>
    </div>
    <div class="col-md-6">
      <h4>Filmes</h4>
      <ul class="list-group">
        <li class="list-group-item"
          :class="{ active: index == currentIndex }" v-for="(filme, index) in filmes" :key="index"
          @click="setarFilmeAtivo(filme, index)">
          {{ filme.id }} - {{ filme.titulo }}          
        </li>
      </ul>
    </div>
    <div class="col-md-6">
      <div v-if="filmeSelecionado">
        <h4>{{ filmeSelecionado.titulo }}</h4>    
        <div>
          <label><strong>Genero:</strong></label> {{ filmeSelecionado.genero.nome }}
        </div>
        <div>
          <label><strong>Diretor:</strong></label> {{ filmeSelecionado.diretor.nome }}
        </div>         
        <div>
          <label><strong>Elenco:</strong></label> {{ filmeSelecionado.elenco }}
        </div>
        <div>
          <label><strong>Sinopse:</strong></label> {{ filmeSelecionado.sinopse }}
        </div>
        <tr>
          <td>
            <button class="badge badge-warning mr-2" @click="editarFilme()">Editar</button>
          </td> 
          <td>
            <button class="badge badge-danger mr-2" @click="deletarFilme()">Deletar</button>
          </td>    
          <td>
            <button class="badge badge-secondary mr-2" @click="fecharDetalhe()">Fechar</button>
          </td>                          
        </tr>
      </div>
      <div v-else>
        <br />
        <p v-if="filmes.length">Clique para ver informações do Filme</p>
      </div>
    </div>
  </div>
</template>

<script>
import BaseService from "../../services/BaseService";

export default {
  name: "filmes-lista",
  data() {
    return {
      filmes: [],
      filmeSelecionado: null,
      currentIndex: -1,
      filmeId: "",
      endpoint: "/filme"
    };
  },

  methods: {
    listarFilmes() {      
      BaseService.getAll(this.endpoint)
        .then(response => {          
          this.filmes = response.data.data;          
        })
        .catch(e => {
          console.log(e);
        });
    },

    atualizarListaFilmes() {
      this.listarFilmes();
      this.filmeSelecionado = null;
      this.currentIndex = -1;
    },

    setarFilmeAtivo(filme, index) {
      this.filmeSelecionado = filme;
      this.currentIndex = index;
    },

    ObterFilmePorId() {
      this.filmes = [];
      this.filmeSelecionado = null;
      this.currentIndex = -1;

      BaseService.get(this.endpoint, this.filmeId)
        .then(response => {
          this.filmeSelecionado = response.data.data   
          
          if (this.filmeSelecionado != null) {
            this.filmes.push(this.filmeSelecionado);
          }          
        })
        .catch(e => {
          console.log(e);
        });
    },

    editarFilme() {
      window.location.href = this.endpoint + '/detalhe/' + this.filmeSelecionado.id;
    },

    deletarFilme() {      
      BaseService.delete(this.endpoint, this.filmeSelecionado.id)
        .then(response => {
          console.log(response.data);
          this.atualizarListaFilmes();
        })
        .catch(e => {
          console.log(e);
        });
    },

    fecharDetalhe() {
      this.filmeSelecionado = null;
      this.currentIndex = -1;
    },
  },
  mounted() {
    this.listarFilmes();
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
