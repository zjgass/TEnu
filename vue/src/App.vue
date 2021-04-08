<template>
  <div id="app">
    <div id="banner">
      <div id='title-and-sub'>
        <h1>TEnue</h1>
        <p>A meal planner by Tech Elevator</p>
        </div>
        <img id='banner-image' src="@/images/spoon-and-fork.gif" alt='fork and knife' width='100' height='90'/>
      </div>
    <div id="nav" v-if="$store.state.token != ''">
      <router-link class='nav-button' v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link class='nav-button' v-bind:to="{ name: 'home2' }">Home 2</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddPlan' }">Add Plan</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddMeal' }">Add Meal</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddRecipe' }" >Add Recipe</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'ViewRecipes' }" >View Recipes</router-link>
      <router-link id='logout-button' class='nav-button' v-bind:to="{ name: 'logout' }" >Logout</router-link>
    </div>
    <router-view id='router' />

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

  height: 20px;
  margin: auto auto 10px;
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
  align-items: center;
  padding: 20px;
  font-family: arial;
  box-shadow: 5px 5px 5px ;
  background-color: #ffd07b;
}

#title-and-sub{
  /* background-color: red; */
  width: 50%;
}

.nav-button:hover{
color: #1789fc;
}


#banner-image{
  /* width: 100px;
  height: 100px;
  background-color: silver;
  margin-top: 0px;
  margin-left: 100%;
  display: block; */
  margin-top: -20px;

}



.nav-button{
  font-size: 20px;
  height: 40px;
  padding-left: 10px;
  padding-right: 10px;
  text-decoration: none;
  margin-left: 10px;
  margin-right: 20px;
  display: flex;
  font-weight: bold;
  align-items: center;
  color: #296eb4;

  
}

#nav .router-link-exact-active{
/* background-color: silver; */
border-bottom: 5px #1789fc solid;
border-radius: 0px;
background-color: #ffd07b;

}

#banner{

padding: 20px;
height: 50px;
border: solid 1px black;
margin: 20px auto 10px;
font-family: arial;
display: flex;
flex-direction: row;
justify-content: space-between;
box-shadow: 5px 5px 5px ;
background-color: #ffd07b;
}

#banner h1{
  max-width: 50%;
  margin-top: 0px;
  margin-bottom: 0px;

}

#banner p{
  margin-top: 0px;
    max-width: 70%;
    

}

#logout-button{
/* align-self: flex-end; */

}


#router{

padding: 20px;
min-height: 600px;
height: auto;
border: solid 1px black;
margin: 0px auto 0px;
font-family: arial;
box-shadow: 5px 5px 5px ;
background-color: #ffd07b;
}

*{
  border-radius: 5px;
}

#app{
  /* width: 1200px;
  margin: 0px auto;
  border-left: 1px solid black;
  border-right: 1px solid black;
  border-radius: 0px; */

}
body, html{
  width: 100%;
  min-height: 100%;
  background-color: red;
}

#nav, #banner, #router{
width: 1200px

}




</style>