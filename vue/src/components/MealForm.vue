<template>
    <div>
        <div id='form-page'>

        <form id='recipe-input' action="" method="">

            <div class='input-line'>
                <p class='input-label'>New Meal Name: </p>
                <input type='text' v-model="meal.name"  />

            </div>

            <div class='input-line'>
                <p class='input-label'>Search Meals: </p>
                <input type='text' name = 'equipment'  />
                <button>Add Recipes</button>
                <button>Clear Recipes</button>
            </div>


            <button v-on:click.prevent="saveMeal()"  id='submit-button'>Add Meal</button>
        </form>

            <div id='current-recipe'>

   
            <h2>Recipe Of The Week </h2>
     
        </div>

    </div>
</div>
</template>

<script>

import mealService from "../services/MealService";

export default {
    name: "meal-form",
    data() {
        return {
            meal: {
               // recipeId: 0, 
                name: "",
                recipeList: []
            }
        };
    },
    methods: {
        saveMeal() {

            this.meal.recipeList = this.$store.state.newMealRecipes;
            mealService.createMeal(this.meal)
            .then(response => {
                if(response.status === 201){
                    console.log("Created meal successfully");
                }
            })
            .catch(error => {
                if(error.response) {
                    this.errorMsg = "Error creating new meal. Response received was '" + error.response.statusText + "'.";
                }
            })
        }
    }

}
</script>

<style>


</style>