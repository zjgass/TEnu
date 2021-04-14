<template>
<div id='app-wrapper'>
  <div id="app">
    <div id="banner">


      <div id='title-and-sub'>
        <h1 id='site-title'>TEnu</h1>
        <p id='subtitle'>A meal planner by Tech Elevator</p>
        </div>

        <img id='banner-image' src="@/images/Grub_logo2_large.png" alt='small banner image' />


        
      </div>
    <div id="nav" v-if="$store.state.token != ''">
      <!-- <router-link class='nav-button' v-bind:to="{ name: 'home' }">Home</router-link> -->
      <router-link class='nav-button' id='home-button' v-bind:to="{ name: 'home2' }">Home</router-link>
      <!-- <router-link  class='nav-button' v-bind:to="{ name: 'AddPlan' }">Add Plan</router-link> -->
      <!-- <router-link  class='nav-button' v-bind:to="{ name: 'AddMeal' }">Add Meal</router-link> -->
      <router-link  class='nav-button' v-bind:to="{ name: 'AddRecipe' }" >Add Recipe</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'ViewRecipes' }" >View Recipes</router-link>
      <router-link  class='nav-button' v-bind:to="{ name: 'GroceryList' }" >Grocery List</router-link>
      <router-link id='logout-button' class='nav-button' v-bind:to="{ name: 'logout' }" >Logout</router-link>
    </div>
    
    <div id='router-wrapper'>
    <router-view id='router' />
    </div>


  </div>


  </div>
</template>


<script>



</script>



<style scoped>
#nav{

background-color: darkcyan;
  height: 60px;
  border-top: black 1px solid;
  border-bottom: black 1px solid;
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
  align-items: center;
  font-family: arial;
  width: 1440px;
  margin: auto;


}

.nav-button{
  font-size: 20px;
  height: 40px;
  padding-left: 10px;
  padding-right: 10px;
  text-decoration: none;
  display: flex;
  justify-content: space-around;
  font-weight: bold;
  align-items: center;
  color: white;
  background-color: darkcyan;
  min-width: 140px;
  border-radius: 10px;
  
 

}

#home-button{
  margin-left: 20px;
}


#nav .active{
color: black;
background-color: white;

}

.nav-button:hover{
color: lightgreen;

}




#banner{

  background-image: url("images/banner-background-1.png");
background-size: cover;
  

  padding: 20px;
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




#app{
  /* width: 85%; */
width: 1440px;
height: auto;
  min-height: 1200px;
  margin: -8px auto;
  border-left: 1px solid black;
  border-right: 1px solid black;
  border-bottom: 1px solid black;
  /* padding: 20px; */
    font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
    opacity: .92;
    background-color: white;
}

#app-wrapper{
  background-image: url("images/banner-image-2.jpg");
  background-size: 100%;


  
}

#banner, #router{
margin:auto;

}

#router-wrapper{
  padding: 40px;
}



#spacer{
  width: 50px;
}


p{
  cursor: pointer;
}


@media(max-width: 1400px) {
#app{
width: 90%}
#home-button{
  margin-left: 0px;
}
#nav, #banner, #router{
/* width: 97.5%; */


margin: auto;
background-size: 100% 100%;
/* background-image: none; */
/* background-color: silver; */

}
#nav{
  display:flex;
  flex-direction: row;
  flex-wrap: wrap;

  height: auto;
  padding: 0px;
  width: 100%;

}

#banner{
 padding: 0px;
   background-image: none;
     background-image: url("images/banner-blank.png");

}



.nav-button{
  margin-top: 0px;
  width: 100%;


}


#router{
  width: 100%;
  height: auto;

}





}

</style>