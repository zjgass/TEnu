<template>
  <div id='recipe-list'>
    <!-- <h1>Add A New Recipe</h1> -->
    <recipe-form />
  </div>
  
</template>

<script>
import RecipeForm from "@/components/RecipeForm";

export default {
  components: {
    RecipeForm
  }
};
</script>
<style scoped>
#recipe-list{
  /* border: 1px solid black;
  margin: 0px auto;
  width: 1000px;
  padding: 20px; */

}

</style>