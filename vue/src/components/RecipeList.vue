<template>
<div>


  <table>

    <thead>
      <tr>
        <th>heading of column 1</th>
        <th>heading of column 2</th>
        <th>heading of column 3</th>

      </tr>
    </thead>

    <tbody>

      <tr class="recipe-row" v-for="recipe in Recipes" :key="recipe.recipeId" v-on:click="viewRecipe(recipe.id)">
        <td>table td</td>
        <td>row: {{ recipe.name }}</td>
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
  methods: {
    viewRecipe(recipeId) {
      this.$router.push(`/recipe/${recipeId}`);
    }
  },
  created() {
    RecipeService.getRecipes().then((response) => {
      this.Recipes = response.data;
    });
  }
};



</script>

<style>

</style>