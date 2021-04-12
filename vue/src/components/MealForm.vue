<template>
    <div>
        <div id='form-page'>
            
        <form id='recipe-input' action="" method="">
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


            <button v-on:click.prevent="saveMeal()"  id='submit-button'>Save Meal</button>
        </form>

            <div id='current-recipe'>

   
            <h2>Recipe Of The Week </h2>
     
        </div>

    </div>
</div>
</template>

<script>

//import mealService from "../services/MealService";

export default {
    name: "meal-form",
   
    data() {
        return {
           
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
                        mealId: "",
                        recipeList: [],
                        mealDay: this.$route.params.mealDay,
                        mealTime: this.$route.params.mealTime,
                        userId: ""
                    }
                    return meal;
                }



            //  return this.$store.state.currentPlan.meals.find((meal) => {
            //     return meal.mealId == this.$route.params.id
            //});
        },
    },
    methods: {
        saveMeal() {
            console.log('executing saveMeal')
            this.meal.recipeList = this.$store.state.newMealRecipes;
            this.$store.commit('ADD_MEAL_TO_CURRENT_PLAN', this.meal)

            this.$router.push('home2');


            /*
           
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
            */
        }
    }

}
</script>

<style>


</style>