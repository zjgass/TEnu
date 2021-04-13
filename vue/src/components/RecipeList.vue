<template>
  <div class="flex-list">
   
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
  } ,
  data() {
    return {
      recipes: []
    }
  },
  created() {
    RecipeService.getRecipes().then((response) => {
      this.recipes = response.data;
    });
  }
};
</script>

<style>

.flex-list {
 
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center flex-start;
 
  width: .5fr;
  
  margin: 5px 10px 5px 10px;
  padding: 0px 0px 0px 0px;
}









/*
    <router-link v-bind:to="{ name: 'RecipeDetailView', params: {id : recipe.recipeId} }">
        
        </router-link>
        */
</style>

