<template>
    <div>
        <div id='form-page'>

        <form id='recipe-input' action="" method="">

            <div class='input-line'>
                <p class='input-label'>name of new recipe: </p>
                <input type='text' v-model="recipe.name"  />
                <p>{{this.$store.state.existingIngredients[0]}}</p>
            </div>

            <div class='input-line'>
                <p class='input-label'>equipment needed: </p>
                <input type='text' v-model="newUtensil"  />
                <button v-on:click="addUtensil().prevent()">Add Equipment</button>
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
                <input type='text' v-model="newInstruction"/>
                <button v-on:click="addInstruction().prevent()">Add Step</button>
                <button>Clear Steps</button>
            </div>

            <button v-on:click="save().prevent()"  id='submit-button'>Submit Recipe</button>
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
import ingredientService from "../services/IngredientService";

export default {
    name: "recipe-form",
    data() {
        return {
            ingredients: [],   
            newInstruction: "",    
            newUtensil: "",   
            recipe: {
               // recipeId: 0, 
                name: "",
                isPublic: "",
                description: "",
                serves: "",
                prepTime: "",
                cookTime: "",
                totalTime: "",
                ingredients: [],
                utensils: [],
                instructions: [],
                imgUrl: "",
                submittedBy: ""
            }
        };
    },
    save(){
     
      
        this.$store.commit("ADD_INGREDIENTS", this.ingredients);
    },
    
    created(){
        this.loadIngredients();

        console.log('loaded recipeform');
    },
    methods: {
        addInstruction(){
            this.recipe.instructions.unshift(this.newInstruction);
            this.newInstruction = "";
         },
        addUtensil(){
            this.recipe.utensils.unshift(this.newUtensil);
            this.newUtensil = "";
        }, 
        saveRecipe() {
            recipeService.addRecipe(this.recipe)
            .then(response => {
                if(response.status === 201){
                    console.log('recipe saved succesfully');
                }
            })
            .catch(error => {
                if(error.response) {
                    console.log('error loading ingredient')
                    this.errorMsg = "Error creating new Recipe. Response received was '" + error.response.statusText + "'.";
                }
            })
        },
        loadIngredients(){
            ingredientService.getIngredients()
            .then(response => {
                console.log(response.status); 
                    this.ingredients = response.data;       
                    console.log('Ingredients Loaded');
                    console.log(this.$store.state.newIngredients[0]);
                }
            )
            .catch(error => {
                if(error.response){
                    this.errorMsg = "Error loading all existing recipes.  Response received was '" + error.response.statusTest + "'.";
                    console.log('load failed');
                }
            })

        }
    },
    

}
</script>

<style>



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




}
#form-page{

    /* border: solid black 1px; */
    display: flex;
    justify-content: space-between;
    /* background-color: silver; */
}


#submit-button{
    width: 90%;
    height: 30px;
    font-size: 16pt;
    margin-top: 20px;
}

@media(max-width: 1200px) {
#form-page{
display: flex;
flex-direction: column;

}



#recipe-input, #current-recipe{
    margin-bottom: 10px;
    width: 90%;

}}

</style>