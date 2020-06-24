<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <a href="/filmes" class="navbar-brand">Filmes</a>
      <div class="navbar-nav mr-auto">
        <li class="nav-item">
          <a href="/diretores" class="nav-link">Diretores</a>
        </li>
      </div>
    </nav>

    <div class="container mt-3">
      <router-view />
    </div>
  </div>
</template>

<script>
export default {
  name: "app"
};
</script>
