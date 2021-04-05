<template>
  <div id="app">
    <div id="banner">
        <h1>Meal Planner</h1>
        <p>subtext</p>
      </div>
    <div id="nav">
      <router-link class='nav-button' v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;&nbsp;
      <router-link class='nav-button' v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />
  </div>
</template>


<script>
// import { defineComponent } from '@vue/composition-api'

// export default defineComponent({
//   setup() {
    

//   },
// })
</script>



<style scoped>
#nav{
  border: 1px black solid;
  width: 1000px;
  height: 20px;
  margin: auto auto 0px;
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 20px;

}
.nav-button{
  font-size: 20px;
  height: 40px;
  text-decoration: none;
  margin-left: 10px;
  display: flex;
  align-items: center;
  
}

#banner{
width: 1000px;
padding: 20px;
height: 50px;
border: solid 1px black;
margin: 20px auto 0px;

}

#banner h1{
  margin-top: 0px;
  margin-bottom: 0px;
}

#banner p{
  margin-top: 0px;
}


</style>