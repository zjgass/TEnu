<template>
  <div class="recipe-list">
   

    
     <recipe-card 
       v-for="recipe in recipes" 
       v-bind:key="recipe.recipeId"
       v-bind:recipe="recipe"
       />


  </div>
</template>

<script>
import RecipeService from "../services/RecipeService";
import RecipeCard from "../components/RecipeCard";


export default {
  name: "recipe-list",
  components: {
    RecipeCard
  },
  props: {
      userOrPublic: String
  } ,
  data() {
    return {
      recipes: [],
      displayType: "user"  
    }
  },

  watch: {
    // whenever question changes, this function will run
    userOrPublic: async function (updateDisplay) {
      this.displayType = updateDisplay;

      if(this.displayType === "user")
      {
       RecipeService.getRecipes().then((response) => {
       this.recipes = response.data;       
         });
      }
    else {
      RecipeService.getPublicRecipes().then((response) => {
        this.recipes = response.data;
      })
    }

       
    }
  },
 
  
  created() {
    
      if(this.displayType === "user")
      {
       RecipeService.getRecipes().then((response) => {
       this.recipes = response.data;       
         });
      }
    else {
      RecipeService.getPublicRecipes().then((response) => {
        this.recipes = response.data;
      })
    }
   
  },
  
  

  
};
</script>

<style>

.recipe-list{
 
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center flex-start;
  flex-wrap: wrap;
  width: .5fr;
  /* margin: 5px 10px 5px 10px; */
  padding: 0px 0px 0px 0px;

  
}






/*
    <router-link v-bind:to="{ name: 'RecipeDetailView', params: {id : recipe.recipeId} }">
        
        </router-link>
        */
</style>

