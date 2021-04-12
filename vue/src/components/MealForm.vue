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

            <div class='input-line'>
                <p class='input-label'>Search Meals: </p>
                <input type='text' name = 'equipment'  />
                <button>Add Recipes</button>
                <button>Clear Recipes</button>
            </div>


            <button v-on:click.prevent="saveMealToPlan()"  id='submit-button'>Save Meal</button>
        </form>

            <div id='current-meal'>

   
            <h2>Recipe Of The Week </h2>
     
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
            returnedMeal: []
           
        };
    },
    computed: {
        meal() {
                if(this.$store.state.currentPlan.meals.find((meal) => {
                return meal.mealId == this.$route.params.id}) != undefined)
                {
                    return this.$store.state.currentPlan.meals.find((meal) => {
                    return meal.mealId == this.$route.params.id
                    })
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
    methods: {
        saveMealToPlan() {
            console.log('executing saveMealToPlan')
            this.meal.recipeList = this.$store.state.newMealRecipes;
            if(this.meal.mealId != 0)
            {
                console.log('saveMealToPlan if true')
                planService.addMeal(this.$store.state.currentPlan.planId,
                                     this.$route.params.mealDay, 
                                     this.$route.params.mealTime, 
                                     this.meal.mealId);

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
                    
                    this.$router.push('home2');
                });
            
             

              
            }
          
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