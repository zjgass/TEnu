<template>
    <div>
        <h1>{{recipe.recipeId}}</h1>
        <h2>{{recipe.name}}</h2>


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