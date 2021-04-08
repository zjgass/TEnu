<template>
  <div class="recipe-list">
    
    <recipe-card v-bind:recipe="recipe" v-for="recipe in recipes" v-bind:key="recipe.recipeId"/>

  </div>

</template>

<script>
import RecipeService from "../services/RecipeService";
import RecipeCard from "../components/RecipeCard.vue";

export default {
  name: "recipe-list",
  components: RecipeCard,
  data() {
    return {
      Recipes: []
    };
  },
  created() {
    RecipeService.getRecipes().then((response) => {
      this.Recipes = response.data;
    });
  }
};
</script>

<style>

.recipe-list{
    column-width: 100px;
}


.icon, .name, .rating{
width: 200px;

}



/*
    <router-link v-bind:to="{ name: 'RecipeDetailView', params: {id : recipe.recipeId} }">
        
        </router-link>
        */
</style>

