<template>
<div>
  <table>

    <thead>
      <tr>
        <th>&nbsp;</th>
        <th>Recipe</th>
        <th>some property of a recipe</th>
        <th>some property of a recipe</th>
      </tr>
    </thead>

    <tbody>
      <tr v-for="recipe in allRecipes" :key="recipe.id" v-on:click="viewDocument(recipe.id)">

        <td>
        </td>

        <td class="name">{{ recipe.name }}</td>
        
        <td>
        </td>
        <td>{{ doc.lastOpened }}</td>
        
      </tr>
    </tbody>

  </table>
</div>


</template>

<script>
// import RecipeService from "../services/RecipeService";

// export default {
//   name: "recipe-list",
//   data() {
//     return {
//       allRecipes: []
//     };
//   },
//   methods: {
//     viewRecipe(recipeid) {
//       this.$router.push(`/recipe/${recipeId}`);
//     }
//   },
//   created() {
//     RecipeService.list().then((response) => {
//       this.allRecipes = response.data;
//     });
//   }
// };
</script>

<style>

</style>