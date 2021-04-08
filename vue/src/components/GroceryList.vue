<template>
<div>

<p>text in grocery list component</p>

<li>v-for list items of ingredients</li>

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