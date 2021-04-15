<template>
  <div>

      <div id='title-and-button-recipes'>
        <p class='list-title'>Showing: {{this.userOrPublic}} Recipes </p>
        <button class='toggle-pubic' v-on:click.prevent="toggleView()">Toggle View</button>
    </div>

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

#title-and-button-recipes{

display: flex;
justify-content: start;
margin-bottom: 40px;
}

.toggle-pubic{

height: 30px;


}

.list-title{

width: auto;
font-size: 20pt;
margin: 0px;
margin-right: 40px;
}


</style>