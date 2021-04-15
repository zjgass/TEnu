<template>
  <div>
    <button v-on:click.prevent="toggleView()">Toggle View</button>
    <p>Showing: {{this.userOrPublic}} Recipes </p>
    <recipe-list v-bind:userOrPublic.sync="userOrPublic"/>
  </div>
</template>

<script>
import RecipeList from "../components/RecipeList.vue";


export default {
  components: {
    RecipeList,
  },
  data(){
    return{
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


</style>