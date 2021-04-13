<template>
  <div>
    <h1>Edit selected meal</h1>
    <meal-form />
    <h1 id='add-meal-instructions'>Click + to add recipe to meal</h1>
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
#add-meal-instructions{
  margin-top: 20px;
}

</style>