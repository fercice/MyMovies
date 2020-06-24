<template>
  <div class="submit-form">    
    <form @submit.prevent="salvarFilme">
      <div v-if="!submitted">
        <h4>Adicionar Filme</h4>
        <div class="form-group">
          <label for="titulo">Titulo</label>
          <input
            type="text"          
            class="form-control"          
            id="titulo"
            autofocus          
            required
            v-model="filme.titulo"
            name="titulo"          
          />
        </div>
        <div class="form-group">
          <label for="elenco">Diretor</label>
          <select class="form-control" v-model="diretorSelecionado" required>
            <option value="" disabled selected>Selecione</option>
            <option v-for="diretor in diretores" :key="diretor.id" :value="diretor">
              {{ diretor.nome }}
            </option>     
          </select>
        </div>
        <div class="form-group">
          <label for="elenco">Genero</label>
          <select class="form-control" v-model="generoSelecionado" required>
            <option value="" disabled selected>Selecione</option>
            <option v-for="genero in generos" :key="genero.id" :value="genero">
              {{ genero.nome }}
            </option>     
          </select>
        </div>
        <div class="form-group">
          <label for="elenco">Elenco</label>
          <textarea 
            class="form-control"
            style="min-height: 75px;"
            id="elenco"
            required
            v-model="filme.elenco"
            name="elenco"
          />
        </div> 
        <div class="form-group">
          <label for="sinopse">Sinopse</label>
          <textarea 
            class="form-control"
            style="min-height: 125px;"
            id="sinopse"
            required
            v-model="filme.sinopse"
            name="sinopse"
          />
        </div>      
        <tr>
          <td><button type="submit" class="btn btn-success">Salvar</button></td>
          <td><a href="/filmes" class="nav-link">Voltar</a></td>
        </tr>
      </div>
      <div v-else>
        <h4>{{ message }}</h4>
        <tr>
          <td><button class="btn btn-success" @click="novoFilme">Novo</button></td>
          <td><a href="/filmes" class="nav-link">Voltar</a></td>
        </tr>                     
      </div>
    </form>
  </div>
</template>

<script>
import BaseService from "../../services/BaseService";

export default {
  name: "adicionar-filme",
  data() {
    return {
      filme: {
        id: null,
        titulo: "",
        elenco: "",
        sinopse: ""
      },      
      diretores: [],
      diretorSelecionado: null,
      generos: [],
      generoSelecionado: null,
      submitted: false,
      message: '',
      endpoint: "/filme",
      endpointDiretor: "/diretor",
      endpointGenero: "/genero"
    };
  },
  methods: {
    listarDiretores() {            
      BaseService.getAll(this.endpointDiretor)
        .then(response => {     
          this.diretores = response.data.data;          
        })
        .catch(e => {
          console.log(e);
        });
    },

    listarGeneros() {            
      BaseService.getAll(this.endpointGenero)
        .then(response => {     
          this.generos = response.data.data;          
        })
        .catch(e => {
          console.log(e);
        });
    },
    
    salvarFilme() {      
      var data = {
        titulo: this.filme.titulo,
        elenco: this.filme.elenco,
        sinopse: this.filme.sinopse,
        diretorId: this.diretorSelecionado.id,
        generoId: this.generoSelecionado.id
      };

      BaseService.create(this.endpoint, data)
        .then(response => {
          this.filme.id = response.data.id;          
          this.submitted = true;
          this.message = 'Filme salvo com sucesso!';
        })
        .catch(e => {
          this.submitted = true;
          this.message = 'Não foi possível salvar';
          console.log(e);
        });
    },
    
    novoFilme() {
      this.submitted = false;
      this.filme = {};
    }
  },
  mounted() {
    this.listarDiretores();
    this.listarGeneros();
  }
};
</script>

<style>
.submit-form {
  max-width: 500px;
  margin: auto;
}
</style>
