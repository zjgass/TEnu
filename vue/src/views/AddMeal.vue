<template>
  <div>
    <h1>Create A New Meal</h1>
    <meal-form />
    <recipe-list/>
    
  </div>
</template>

<script>
import MealForm from "@/components/MealForm";
import RecipeList from "@/components/RecipeList";

export default {
  components: {
    MealForm,
    RecipeList
  }
};
</script>
<style scoped>


</style>