<template>
    <div>
        <div id='form-page'>

        <!-- <form id='meal-input' action="" method=""> -->
            
        <form id='meal-input' action="" method="">
            <div class='meal-card-test'>
                <h3>Editing {{meal.mealDay}} {{meal.mealTime}} in {{this.$store.state.currentPlan.name}} plan </h3>
            </div>
            <div class='input-line'>
                <p class='input-label' >Meal Name: </p>
                <input type='text' v-model="meal.name"  />

            </div>



            <button v-on:click.prevent="saveMealToPlan()"  id='submit-button'>Save Meal</button>
        </form>

            <div id='current-meal'>
                <h2>{{meal.name}} contains the following recipes</h2>
                <ul >
                     <li class='meal-recipe-list' v-for="recipe in meal.recipeList" v-bind:key="recipe.recipeId"  v-bind:value='recipe.recipeId' >
                        <h4>{{recipe.name}}</h4>
                        <button v-on:click.prevent='removeThisRecipe(recipe.recipeId)' class='meal-recipe-list-removeBtn'>Remove Recipe</button>
                     </li>
                     <li class='meal-recipe-list' v-for="recipe in this.$store.state.newMealRecipes" v-bind:key="recipe.recipeId" v-bind:value='recipe.recipeId'>
                         <h4>{{recipe.name}}</h4>
                         <button v-on:click.prevent='removeThisNewRecipe(recipe.recipeId)' class='meal-recipe-list-removeBtn'>Remove Recipe</button>
                         </li>
                </ul>



        </div>

    </div>
</div>
</template>

<script>

import planService from "../services/PlanService";
import mealService from "../services/MealService";

export default {
    name: "meal-form",
  
    data() {
        return {
            returnedMeal: [],
            //set to invalid id at start
            removeRecipeId: -1,
            addRecipeId: -1,
         
        };
    },
    watch: {  
        removeRecipeId: async function (deleteRecipe) {
         this.removeRecipeId = deleteRecipe;
         if(this.mealId != 0){
            mealService.deleteRecipeFromMeal(this.meal.mealId, deleteRecipe).then((response) => {
                 //needs actual error handling
                 console.log(response + 'recipe removed from meal successfully');
                let indexFound = this.meal.recipeList.findIndex(element => {
                    console.log(element.recipeId);
                        if(element.recipeId == deleteRecipe){
                        console.log('element = ' + element);
                        return element;
                         }
                         
                        return false;
                })

                console.log(indexFound);

                 this.meal.recipeList.splice(indexFound, 1);
                 //this.removeRecipeId = -1;
                 //this.$forceUpdate();
             })

            // this.meal.recipeList.splice(this.getRecipeIndex(deleteRecipe), 1);
           
            }
         else{
            this.meal.recipeList.splice(this.getRecipeIndex(deleteRecipe), 1);

         }

        },
        addRecipeId: async function (addRecipe) {
            this.addRecipeId = addRecipe;
            this.meal.recipeList.unshift(this.addRecipeId);
            if(this.meal.mealId != -1)
            {
                mealService.addRecipeToMeal(this.meal.mealId, addRecipe).then((response) => {
                    //needs actual error handling
                console.log(response + 'recipe added to meal successfully');   
                })        
                this.addRecipeId = -1;


                


            }
            else 
            {
                mealService.createMeal(this.meal);
                this.addRecipeId = -1;
                let clearRecipeList = [];
                this.$store.commit("STORE_MEAL_RECIPES", clearRecipeList);
            }


        }
   
    },
    computed: {
        meal() {
                if(this.$store.state.currentPlan.meals.find((meal) => {
                return meal.mealId == this.$route.params.id}) != undefined)
                {
                    let returnMeal = this.$store.state.currentPlan.meals.find((meal) => {
                    
                    return meal.mealId == this.$route.params.id
                    })

                    returnMeal.mealDay = this.$route.params.mealDay;
                    returnMeal.mealTime = this.$route.params.mealTime;
                    return returnMeal;
                }
                else{
                    let meal = {
                        name: "",
                        mealId: 0,
                        recipeList: [],
                        mealDay: this.$route.params.mealDay,
                        mealTime: this.$route.params.mealTime,
                        //userId: ""
                    }
                    return meal;
                }



            //  return this.$store.state.currentPlan.meals.find((meal) => {
            //     return meal.mealId == this.$route.params.id
            //});
        },
    },
    created() {
        this.$store.commit('SET_CURRENT_MEAL_ID', this.$route.params.id);
        let clearRecipeList = [];
        this.$store.commit("STORE_MEAL_RECIPES", clearRecipeList);
    },
    methods: {
        removeThisRecipe(recipeId) {
            this.removeRecipeId = recipeId;

        },
        removeThisNewRecipe(recipeId) {
            this.$store.commit("REMOVE_RECIPE_FROM_MEAL", recipeId)
        },
        addThisRecipe(recipeId) {
            this.addRecipeId = recipeId;
        },
        saveMealToPlan() {
            console.log('executing saveMealToPlan')
            this.meal.recipeList = this.$store.state.newMealRecipes;
            if(this.meal.mealId != 0)
            {

                console.log('saveMealToPlan if true')
                let clearRecipeList = [];
                this.$store.commit("STORE_MEAL_RECIPES", clearRecipeList);
                this.$router.push('home2');
            }
            //create new meal first then add meal to plan
            else{
                console.log('saveMealToPlan if false')
              
                mealService.createMeal(this.meal)
                .then(response => {
                    this.returnedMeal = response.data;
                    console.log('new meal id = ' + this.returnedMeal);
                    
                    planService.addMeal(this.$store.state.currentPlan.planId,
                                     this.$route.params.mealDay, 
                                     this.$route.params.mealTime, 
                                     this.returnedMeal.mealId);

                    mealService.addRecipeToMeal(this.returnedMeal.mealId, this.$store.state.newMealRecipes[0]);

                    let clearRecipeList = [];
                    this.$store.commit("STORE_MEAL_RECIPES", clearRecipeList);
  
                    this.$router.push('home2');
                }); 
            }
        },
        createNewPlan(){
          this.enterNewPlanName = true;
        },
        getRecipeIndex(recipeId){
           this.meals.recipeList.findIndex(element => {
              if(element.recipeId == recipeId){
                  console.log('element = ' + element);
                  return element;
              }
              return false;
          })
        }
    }
}
</script>

<style>

#meal-input, #current-meal{
    width: 45%;
min-height: 600px;
  box-shadow:0 4px 8px 0 darkcyan, 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 5px;
  padding: 20px;
}

.meal-recipe-list {
    display: flex;
    justify-content:flex-start;
    align-content: flex-start;
}

.meal-recipe-list-removeBtn {
    margin: 10px 10px 10px 10px;
    width: 75px;
    height: 50px;

}

@media(max-width: 1400px) {

#meal-input, #current-meal{

width: 95%;
width: 95%;
margin: 10px auto;

}
#form-page{
    display:flex;
    flex-direction: column;
}

}



</style>