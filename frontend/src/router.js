import Vue from "vue";
import Router from "vue-router";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      alias: "/filmes",
      name: "filmes",
      component: () => import("./views/filme/FilmeLista")
    },
    {
      path: "/filmes",      
      name: "filmes",
      component: () => import("./views/filme/FilmeLista")
    },
    {
      path: "/filme/detalhe/:id",
      name: "filme-detalhe",
      component: () => import("./views/filme/FilmeDetalhe")
    },
    {
      path: "/filme/adicionar",
      name: "filme-adicionar",
      component: () => import("./views/filme/FilmeAdicionar")
    },
    {
      path: "/diretores",      
      name: "diretores",
      component: () => import("./views/diretor/DiretorLista")
    },
    {
      path: "/diretor/detalhe/:id",
      name: "diretor-detalhe",
      component: () => import("./views/diretor/DiretorDetalhe")
    },
    {
      path: "/diretor/adicionar",
      name: "diretor-adicionar",
      component: () => import("./views/diretor/DiretorAdicionar")
    }       
  ]
});