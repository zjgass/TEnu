<template>
    <div>
        <div id='form-page'>

        <form id='recipe-input' action="" method="">

            <div class='input-line'>
                <p class='input-label'>New Meal Name: </p>
                <input type='text' v-model="recipe.name"  />

            </div>

            <div class='input-line'>
                <p class='input-label'>Search Meals: </p>
                <input type='text' name = 'equipment'  />
                <button>Add Recipe</button>
                <button>Clear Recipes</button>
            </div>


            <button  id='submit-button'>Add Meal</button>
        </form>

            <div id='current-recipe'>

   
            <h2>Recipe Of The Week </h2>
     
        </div>

    </div>
</div>
</template>

<script>

import recipeService from "../services/RecipeService";

export default {
    name: "recipe-form",
    data() {
        return {
            recipe: {
               // recipeId: 0, 
                name: "",
                isPublic: "",
                serves: "",
                prepTime: "",
                cookTime: "",
                totalTime: "",
                ingredients: [],
                utensils: [],
                instructions: [],
                imgUrl: ""
            }
        };
    },
    methods: {
        saveRecipe() {
            recipeService.addRecipe(this.recipe)
            .then(response => {
                if(response.status === 201){
                    console.Log("Created successfully");
                }
            })
            .catch(error => {
                if(error.response) {
                    this.errorMsg = "Error creating new Recipe. Response received was '" + error.response.statusText + "'.";
                }
            })
        }
    }

}
</script>

<style>


</style>