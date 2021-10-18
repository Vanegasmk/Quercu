<template>
  <div id="nav">
    <Header/>
  </div>
  <router-view/>
</template>

<script>
import Header from './components/Header';
export default ({
  components:{
    Header
  }
})
</script>
