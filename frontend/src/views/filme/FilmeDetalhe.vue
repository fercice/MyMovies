<template>
  <div v-if="filmeSelecionado" class="edit-form">
    <h4>Editar Filme</h4>
    <form @submit.prevent="salvarFilme">
      <div class="form-group">
          <label for="titulo">Titulo</label>
          <input
            type="text"          
            class="form-control"          
            id="titulo"
            autofocus          
            required
            v-model="filmeSelecionado.titulo"
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
            v-model="filmeSelecionado.elenco"
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
            v-model="filmeSelecionado.sinopse"
            name="sinopse"
          />
        </div>    
        <tr>
          <td><button type="submit" class="badge badge-success">Salvar</button></td>
          <td><button class="badge badge-danger mr" @click="deletarFilme">Deletar</button></td>
          <td><a href="/filmes" class="nav-link">Voltar</a></td>
        </tr> 
        <br />
        <h4>{{ message }}</h4>
    </form>
  </div>

  <div v-else>
    <br />
    <h4>Nenhum registro encontrado</h4>
  </div>
</template>

<script>
import BaseService from "../../services/BaseService";

export default {
  name: "filme",
  data() {
    return {
      filmeSelecionado: null,
      diretores: [],
      diretorSelecionado: null,
      generos: [],
      generoSelecionado: null,
      message: '',
      endpoint: "/filme",
      endpointDiretor: "/diretor",
      endpointGenero: "/genero"
    };
  },
  methods: {
    getFilme(id) {
      BaseService.get(this.endpoint, id)
        .then(response => {                    
          this.filmeSelecionado = response.data.data;          
          this.diretorSelecionado = this.filmeSelecionado.diretor;
          this.generoSelecionado = this.filmeSelecionado.genero;
        })
        .catch(e => {
          console.log(e);
        });
    },

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
      this.filmeSelecionado.diretorId = this.diretorSelecionado.id;
      this.filmeSelecionado.generoId = this.generoSelecionado.id;

      BaseService.update(this.endpoint, this.filmeSelecionado.id, this.filmeSelecionado)
        .then(response => {
          console.log(response.data);          
          this.message = 'Filme salvo com sucesso!';
        })
        .catch(e => {
          console.log(e);
        });
    },

    deletarFilme() {
      BaseService.delete(this.endpoint, this.filmeSelecionado.id)
        .then(response => {
          console.log(response.data);
          window.location.href = '/filmes';
        })
        .catch(e => {
          console.log(e);
        });
    }
  },
  mounted() {
    this.message = '';
    this.getFilme(this.$route.params.id);
    this.listarDiretores();
    this.listarGeneros();
  }
};
</script>

<style>
.edit-form {
  max-width: 500px;
  margin: auto;
}
</style>
