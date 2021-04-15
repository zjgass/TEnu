<template>
  <div class="recipe-wrapper">
   

    <div class ="recipe">
         <router-link  v-bind:to="{ name: 'RecipeDetailView', params: {id : recipe.recipeId} }">
        <div class="recipe-name">
             <h1>{{recipe.name}}</h1>
        </div>
        <div class ="recipe-serves">
          <h3>Serves: {{recipe.serves}}</h3>
          </div>
        <div class="stars">
          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="orange" class="bi bi-star-fill" viewBox="0 0 16 16">
             <path d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z"/>
          </svg><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="orange" class="bi bi-star-fill" viewBox="0 0 16 16">
  <path d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z"/>
            </svg><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="orange" class="bi bi-star-fill" viewBox="0 0 16 16" >
            <path d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z"/>
            </svg><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="orange" class="bi bi-star-fill" viewBox="0 0 16 16">
             <path d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z"/>
            </svg><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="black" class="bi bi-star-fill" viewBox="0 0 16 16">
            <path d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z"/>
            </svg>
        </div>
        <div class="recipe-img">
          <img :src='recipe.imgUrl'/>
        </div>
         <div class="recipe-description">
           <h3>{{recipe.description}}</h3>
           </div>
            <div class="recipe-preptime">
          <h3> Total Prep Time: {{recipe.totalTime}}</h3>
          </div>
          <div class="recipe-author">
            <h3> Submitted by {{recipe.author}}</h3>
            </div>
        </router-link>
          <div class="recipe-buttons">
            <a v-on:click="deleteRecipe(recipe.recipeId)" v-if="!addToMealView">
            <svg  xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
             <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
            </svg>
            </a>
             <a v-on:click="deleteRecipeFromMeal(recipe.recipeId)" v-if="addToMealView">
            <svg  xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
             <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
            </svg>
            </a>
            <a v-on:click="addRecipeToMeal(recipe)" v-if="addToMealView">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle-fill" viewBox="0 0 16 16">
               <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"/>
              </svg>
              </a>
          </div>

       </div>
   
  </div>

</template>

<script> 

import recipeService from "@/services/RecipeService.js";
import mealService from "@/services/MealService.js";

export default {
  name: 'recipe-card',
  props: ["recipe"],
  data() {
      return {
        addToMealView: true
    }
  },
  methods: {
    deleteRecipe(id) {
      console.log('deleteRecipe run ')
      recipeService.deleteRecipe(id)
      .then(response => {
        if(response.state === 200){
          //implement msg here?
        }
      })
    },
    addRecipeToMeal(recipe) {
      this.$store.commit("ADD_RECIPE_TO_MEAL", recipe);
      this.$store.dispatch('addRecipeToMealRequest', recipe.recipeId);

    },
    deleteRecipeFromMeal(recipeId){
      console.log('deleteRecipeFromMeal');
      this.$store.commit("DELETE_RECIPE_FROM_MEAL", recipeId);
      //need current mealId somehow
      mealService.deleteRecipeFromMeal(this.$route.params.id, recipeId)
    }
  }
}
//<button v-on:click="deleteRecipe(recipe.recipeId)">Delete</button>
</script>

<style>

.recipe {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center flex-start;
  box-shadow:0 4px 8px 0 darkcyan, 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 5px;
  width: 200px;
  height: 325px;
  margin: 5px 10px 5px 10px;
  padding: 0px 0px 0px 0px;
}
.recipe-name>h1 {
  
    font-size: 1.25rem;
    margin: 5px 0px 0px 0px;
}


.recipe-name {
  
    font-size: .75rem;
    margin: 5px 0px 0px 0px;
}

.recipe-description {
    font-size: .6rem;
    padding: 0px 0px 0px 0px;
}

.recipe-serves>h3 {
   font-size: .6rem;
}
.stars {
   padding: 0px 0px 0px 0px;
   display: flex;
   justify-content: center;
   width: 80%;


}

.recipe-img{
margin-right: auto;
align-content: center;
display: flex;
justify-content: space-around;
}
.recipe-preptime {
  font-size: .7rem;
}

.recipe-author {
  font-size : .65rem;
}

.recipe-buttons {
  display: flex;
}

img {
    height: 100px;
    width: 100px;
    border-radius: 10px;
}

/*override vues crummy formatting for router links with this */
a:-webkit-any-link{
    text-decoration-color: black;
    text-decoration: none;
    color: black;
}
</style>