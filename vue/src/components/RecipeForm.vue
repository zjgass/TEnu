<template>
    <div>
        <div id='new-recipe-page'>

        <form id='recipe-input' action="" method="">

            <div class='input-line'>
                <p class='input-label'>name of new recipe: </p>
                <input type='text' v-model="recipe.name"  />

            </div>

            <div class='input-line'>
                <p class='input-label'>equipment needed: </p>
                <input type='text' name = 'equipment'  />
                <button>Add Equipment</button>
                <button>Clear Equipment</button>
            </div>

            <div class='input-line'>
                <p class='input-label'>ingredients: </p>
                <input type='text' name = 'meal-name'  />
                <button>Add Ingredient</button>
                <button>Clear Ingredients</button>
            </div>

            <div class='input-line'>
                <p class='input-label'>Instructions: </p>
                <input type='text' name = 'meal-name'  />
                <button>Add Step</button>
                <button>Clear Steps</button>
            </div>

            <button  id='submit-button'>Submit Recipe</button>
        </form>

            <div id='current-recipe'>
                <h2>Recipe Name: </h2>
            <p> {{recipe.name}}</p>
            <h2>Required utensils: </h2>
            <ul>
                <li >list item in equipment list</li>
            </ul>
            <h2>Required Ingredients: </h2>
            <ul>
                <li>list of ingredients</li>
            </ul>
            <h2>Instructions: </h2>
            <ul>
                <li>list item in instructions list</li>
            </ul>
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


#form{

}


li, p{
    font-size: 16pt;
}



h2{
    margin-top: 0px
}

.input-line{
    


    /* border: 1px solid black; */
    padding: 10px;
    border-radius: 5px;
    margin-bottom: 10px;
}
.input-label{
    margin-top: 0px;
    
}

#recipe-input{
    border: 1px solid black;
    width: 47%;
    padding: 10px;
    border-radius: 5px;
    min-height: 300px;
    /* margin-right: 5px; */


}
#current-recipe{

    width: 47%;
    min-height: 300px;
    height: auto;
    padding: 10px;
    border: solid 1px black;
    /* margin-left: 5px; */
    border-radius: 5px;



}
#new-recipe-page{

    /* border: solid black 1px; */
    display: flex;
    justify-content: space-between;

}


#submit-button{
    width: 90%;
    height: 30px;
    font-size: 16pt;
    margin-top: 20px;
}



</style>