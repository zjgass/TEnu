<template>
  <div>
    <recipe-detail v-bind:recipe-id="$route.params.recipeId" />
  </div>
</template>

<script>
import RecipeDetail from "@/components/RecipeDetail.vue";

export default {
    name: 'Recipe',
    components: {
    RecipeDetail
  }
};
</script>
