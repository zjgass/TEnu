<template>
<div>


  <table class='recipe-list'>

    <thead>
      <tr>
        <th class='icon'>icon</th>
        <th class='name'>recipe name</th>
        <th class='rating'>rating</th>

      </tr>
    </thead>

    <tbody>
      <tr v-for="recipe in Recipes" :key="recipe.recipeId" >

        <td>
        </td>
        
        <router-link v-bind:to="{ name: 'RecipeDetailView', params: {id : recipe.recipeId} }">
        <td class="name">{{ recipe.name }}</td>
        </router-link>
        <td>
        </td>
        <td></td>
        
      </tr>

    </tbody>

  </table>
</div>


</template>

<script>
import RecipeService from "../services/RecipeService";

export default {
  name: "recipe-list",
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


</style>