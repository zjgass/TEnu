<template>
  <div id="app">
    <div id="banner">
        <h1>Meal Planner</h1>
        
        <p>subtext</p>
        <!-- <img id='banner-image' src="/spoon-and-fork" alt='fork and knife' width='100' height='100'/> -->
      </div>
    <div id="nav" v-if="$store.state.token != ''">
      <router-link class='nav-button' v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddPlan' }">Add Plan</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddMeal' }">Add Meal</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddRecipe' }" >Add Recipe</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: '' }" >View Recipes</router-link>
      <router-link id='logout-button' class='nav-button' v-bind:to="{ name: 'logout' }" >Logout</router-link>
    </div>
    <router-view id='router' />
    <plan-form />
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
  margin: auto auto 10px;
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
  align-items: center;
  padding: 20px;
  font-family: arial;

}

.nav-button :hover{
background-color: red;

}
#banner-image{
  width: 100px;
  height: 100px;
  background-color: silver;
  margin-top: 0px;
  margin-left: 100%;
  display: block;

}



.nav-button{
  font-size: 20px;
  height: 40px;
  text-decoration: none;
  margin-left: 10px;
  margin-right: 20px;
  display: flex;

  align-items: center;

  
}

#banner{
width: 1000px;
padding: 20px;
height: 50px;
border: solid 1px black;
margin: 20px auto 10px;
font-family: arial;

}

#banner h1{
  max-width: 50%;
  margin-top: 0px;
  margin-bottom: 0px;

}

#banner p{
  margin-top: 0px;
    max-width: 50%;
    

}

#logout-button{
/* align-self: flex-end; */

}


#router{
width: 1000px;
padding: 20px;
min-height: 600px;
height: auto;
border: solid 1px black;
margin: 0px auto 0px;
font-family: arial;
}

*{
  border-radius: 5px;
}

#app{
  /* margin-top: 0px;
  border-left: 1px solid black;
  border-right: 1px solid black;
  border-radius: 0px; */
}


</style>