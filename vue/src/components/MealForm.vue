<template>
    <div>
        <div id='form-page'>

        <form id='meal-input' action="" method="">

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

            <div id='current-meal'>

   
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

#meal-input, #current-meal{
    width: 45%;
min-height: 600px;
  box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 5px;
  padding: 20px;
}

@media(max-width: 1400px) {

#meal-input, #current-meal{

width: 95%;
width: 95%;

}
#form-page{
    display:flex;
    flex-direction: column;
}

}



</style>