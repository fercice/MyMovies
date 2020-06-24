<template>
  <div v-if="diretorSelecionado" class="edit-form">
    <h4>Editar Diretor</h4>
    <form @submit.prevent="salvarDiretor">
      <div class="form-group">
        <label for="title">Nome</label>
        <input type="text" class="form-control" id="nome" v-model="diretorSelecionado.nome" required/>
      </div>
      <tr>
        <td><button type="submit" class="badge badge-success">Salvar</button></td>
        <td><button class="badge badge-danger mr" @click="deletarDiretor">Deletar</button></td>
        <td><a href="/diretores" class="nav-link">Voltar</a></td>
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
  name: "diretor",
  data() {
    return {
      diretorSelecionado: null,      
      message: '',
      endpoint: "/diretor"
    };
  },
  methods: {
    getDiretor(id) {
      BaseService.get(this.endpoint, id)
        .then(response => {
          this.diretorSelecionado = response.data.data;          
        })
        .catch(e => {
          console.log(e);
        });
    },

    salvarDiretor() {
      BaseService.update(this.endpoint, this.diretorSelecionado.id, this.diretorSelecionado)
        .then(response => {
          console.log(response.data);
          this.message = 'Diretor salvo com sucesso!';
        })
        .catch(e => {
          console.log(e);
        });
    },

    deletarDiretor() {
      BaseService.delete(this.endpoint, this.diretorSelecionado.id)
        .then(response => {
          console.log(response.data);
          window.location.href = '/diretores';
        })
        .catch(e => {
          console.log(e);
        });
    }
  },
  mounted() {
    this.message = '';
    this.getDiretor(this.$route.params.id);
  }
};
</script>

<style>
.edit-form {
  max-width: 500px;
  margin: auto;
}
</style>
