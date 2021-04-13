<template>
    <div id='detail-box'>
        
        <div id='recipe-box'>
        <h1 id='recipe-title'>{{recipe.name}}</h1>
        <button v-on:click.prevent="saveRecipe()"> Save Changes </button>
        <input class="input-short-text" type='text' v-model="recipe.name"/>
        <h2>serves: {{recipe.serves}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.serves"/>
        <h2>prep time: {{recipe.prepTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.prepTime"/>
        <h2>cook time: {{recipe.cookTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.cookTime"/>
        <h2>total time: {{recipe.totalTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.totalTime"/>
        <h2>ingredients:</h2>
        <ul>
            <li v-for="item in recipe.ingredients" :key="item" >{{ item.name }} Qty: {{item.qty}} {{item.unit}}
                <p class="buttons" v-on:click="deleteIngredient(item)"> x </p></li>
        </ul>
        <h2>utensils: </h2>
            <!--<li v-for="item in recipe.utensils" :key="item"> {{item}}</li>-->
        <h2>instructions: {{recipe.instructions}}</h2>
        </div>

      <!-- <tr v-for="recipe in Recipes" :key="recipe.recipeId" > -->
<div id='image-box'>
    <img src="recipe.imgUrl" alt='image of completed recipe' />




    </div>


    </div>
</template>


<script>
import recipeService from '@/services/RecipeService';

export default {
    name: 'recipe-edit',
    data(){
        return {
            recipe: []
           
        }
    },
    computed: {
   
    },
    methods:{
     saveRecipe(){
         recipeService.updateRecipe(this.recipe)
         .then(response => {
             if(response.status === 200){
                 console.log('recipe updated succesfully');
             }
         })
         .catch(error => {
                if(error.response) {
                    console.log('error saving recipe')
                    this.errorMsg = "Error creating updating Recipe. Response received was '" + error.response.statusText + "'.";
                }
            })
        },
        deleteIngredient(item){
           console.log("Attempting to delete ingredient."); 
           this.recipe.ingredients.splice((this.recipe.ingredients.indexOf(item)),1);
        }
    },
    created() {
        console.log("Started loading recipe to edit.")
        recipeService.getRecipe(this.$route.params.idedit)
                    .then(response => {
                    this.recipe =  response.data;
            });
    }

}


</script>

<style scoped>

#recipe-title{
text-decoration: underline;
margin-top: 0px;
text-transform: capitalize;

}

#recipe-box, #image-box{
    /* border: 1px solid black; */
    width: 45%;
    padding: 10px;
    border-radius: 5px;

}
#detail-box{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    height: 600px;
}
#image-box{
    height: 50%;
}
</style>