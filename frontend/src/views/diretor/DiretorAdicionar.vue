<template>
  <div class="submit-form">  
    <form @submit.prevent="salvarDiretor">
      <div v-if="!submitted">
        <h4>Adicionar Diretor</h4>
        <div class="form-group">
          <label for="nome">Nome</label>
          <input
            type="text"          
            class="form-control"          
            id="nome"
            autofocus          
            required
            v-model="diretor.nome"
            name="nome"          
          />
        </div>           
        <tr>
          <td><button type="submit" class="btn btn-success">Salvar</button></td>
          <td><a href="/diretores" class="nav-link">Voltar</a></td>
        </tr>
      </div>
      <div v-else>
      <h4>{{ message }}</h4>
      <tr>
        <td><button class="btn btn-success" @click="novoDiretor">Novo</button></td>
        <td><a href="/diretores" class="nav-link">Voltar</a></td>
      </tr>                     
    </div>
    </form>    
  </div>
</template>

<script>
import BaseService from "../../services/BaseService";

export default {
  name: "adicionar-diretor",
  data() {
    return {
      diretor: {
        id: 0,
        nome: ""
      },
      submitted: false,
      message: '',
      endpoint: "/diretor"
    };
  },
  methods: {
    salvarDiretor() {
      var data = {
        nome: this.diretor.nome
      };

      BaseService.create(this.endpoint, data)
        .then(response => {
          this.diretor.id = response.data.id;          
          this.submitted = true;
          this.message = 'Diretor salvo com sucesso!';
        })
        .catch(e => {
          this.submitted = true;
          this.message = 'Não foi possível salvar';
          console.log(e);
        });
    },
    
    novoDiretor() {
      this.submitted = false;
      this.diretor = {};
    }    
  }
};
</script>

<style>
.submit-form {
  max-width: 500px;
  margin: auto;
}
</style>
