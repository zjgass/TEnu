<template>
  <div id="app">
    <div id="banner">
      <div id='title-and-sub'>
        <h1 id='site-title'>TEnue</h1>
        <p id='subtitle'>A meal planner by Tech Elevator</p>
        </div>

        <img id='banner-image' src="@/images/Grub_logo2_large.png" alt='fork and knife' />


        
      </div>
    <div id="nav" v-if="$store.state.token != ''">
      <!-- <router-link class='nav-button' v-bind:to="{ name: 'home' }">Home</router-link> -->
      <router-link class='nav-button' v-bind:to="{ name: 'home2' }">Home</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddPlan' }">Add Plan</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddMeal' }">Add Meal</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'AddRecipe' }" >Add Recipe</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'ViewRecipes' }" >View Recipes</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'GroceryList' }" >Grocery List</router-link>
      <p class='spacer'></p>
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

background-color: lightgrey;
  height: 20px;
  border-top: black 1px solid;
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
  align-items: center;
  font-family: arial;





}

.nav-button{
  font-size: 20px;
  height: 60px;
  padding-left: 10px;
  padding-right: 10px;
  text-decoration: none;
  display: flex;
  justify-content: space-around;
  font-weight: bold;
  align-items: center;
  color: white;
  background-color: darkcyan;
  min-width: 120px;
  border-left: 2px solid black;

  
}

#logout-button{
    border-right: 2px solid black;
}

.nav-button:hover{
color: cyan;
}

#nav .router-link-exact-active{
color: black;
background-color: white;

}

#banner{
  /* background-color: cyan; */
  background-image: url("images/banner-image.png");
  background-repeat: no-repeat;
  background-size: 100%;
  
  display: flex;
  flex-direction: row;
  justify-content: space-between;

}
#banner-image{
justify-self: flex-end;
width: 200px;
height: 200px;

}

#site-title{

margin-top: 10px;
  margin-bottom: 0px;
  font-size: 56pt;
}

#subtitle{

  margin-top: 0px;
  font-size: 24pt;
}

#title-and-sub{

  width: 50%;
  padding: 10px;

}

#spacer{
  width: 50%;
}


#app{
  width: 1440px;
  min-height: 2000px;
  margin: -8px auto;
  border-left: 1px solid black;
  border-right: 1px solid black;
  /* padding: 20px; */
    font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
}



#nav, #banner, #router{
width: 1400px;
padding: 20px;
margin: auto;


}

#spacer{
  width: 50px;
}


#router{}

</style>