<template>
  <div>
    <h1>Edit selected meal</h1>
    <meal-form />
    <button v-on:click.prevent="toggleView()">Toggle View</button>
    <p>Showing: {{this.userOrPublic}} Recipes </p>
    <recipe-list v-bind:userOrPublic.sync="userOrPublic"/>
    
  </div>
</template>

<script>
import MealForm from "@/components/MealForm";
import RecipeList from "@/components/RecipeList";

export default {
  components: {
    MealForm,
    RecipeList
  },
  data() {
    return {
      userOrPublic: "user"
    }
  },
  methods: {
      toggleView() {
        if(this.userOrPublic == "user"){
          this.userOrPublic = "public";
        }else{ 
          this.userOrPublic = "user";
        }

        this.$forceUpdate();
        
      }
  }
};
</script>
<style scoped>
#add-meal-instructions{
  margin-top: 20px;
}

</style>