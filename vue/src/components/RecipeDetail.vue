<template>
    <div id='detail-box'>
        

        <div id='recipe-box'>
        <h1 id='recipe-title'>{{recipe.name}}</h1>
        <h2>serves: {{recipe.serves}}</h2>
        <h2>prep time: {{recipe.prepTime}}</h2>
        <h2>cook time: {{recipe.cookTime}}</h2>
        <h2>total time: {{recipe.totalTime}}</h2>
        <h2>ingredients: {{recipe.ingredients}}</h2>
        <ul>
            <li v-for="{name} in recipe.ingredients" :key="name" >{{ {qty} }}</li>
        </ul>
        <h2>utensils: {{recipe.utensils}}</h2>
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
    name: 'recipe-detail',
    props: {
        'recipeId' : Number
    },
    data(){
        return {
            recipe: {
                recipeId: 0,
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
            },
        }
    },
    created() {
        recipeService.getRecipe(this.$route.params.id)
        .then(response => {
            this.recipe = response.data;
        })
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
    border: 1px solid black;
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