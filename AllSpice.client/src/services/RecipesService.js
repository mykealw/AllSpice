import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { accountService } from "./AccountService.js"
import { api } from "./AxiosService.js"


class RecipesService {

    async getAll() {
        const res = await api.get('api/recipes')
        logger.log(res.data, "all recipes")
        AppState.recipes = res.data
    }

    async getMyRecipes() {

        await this.getAll()
        // debugger
        logger.log(AppState.account.id, "user")
        AppState.myRecipes = AppState.recipes.filter(r => r.creatorId == AppState.account.id)
        AppState.recipes = AppState.myRecipes

        logger.log(AppState.recipes, "my recipes")
    }

    async getMyFavs(){
        await this.getAll()
        await accountService.getMyFavs()
        newArr = []
       AppState.myFavorites.forEach(f => f.creator)
    }

    async getActiveRecipe(recipeId) {
        const res = await api.get('api/recipes/' + recipeId)
        logger.log(res.data, "active recipe")
        AppState.activeRecipe = res.data
    }

    async createRecipe(body) {

        const res = await api.post('api/recipes' + body)
        logger.log(res.data, "recipe made")
        AppState.recipes = AppState.recipes.unshift(res.data)
        AppState.myRecipes = AppState.myRecipes.unshift(res.data)
        accountService.getMyFavs()
    }

    async deleteRecipe(id) {
        const res = await api.delete('api/recipes/' + id)
        logger.log(res.data, "deleted")
        AppState.recipes = AppState.recipes.filter(r => r.id != id)
        AppState.myRecipes = AppState.myRecipes.filter(r => r.id != id)
    }

    async createFavorite(favorite) {
        logger.log(favorite, "coming in")
        // let recipeData = {}
        // recipeData.recipeId = id
        // recipeData.accountId = AppState.user.id
        // logger.log(recipeData, "going through")
        const res = await api.post('api/favorites', favorite)
        // logger.log(res.data, "favorited")
        AppState.favorites = AppState.favorites.unshift(res.data)
        AppState.myFavorites = AppState.myFavorites.unshift(res.data)
    }

    async deleteFavorite(recipeId) {
        let gone = null
        gone = AppState.myFavorites.find(mf => mf.id == recipeId)
        // logger.log(gone, "gone?")
        // deleteId = AppState.myFavorites.filter(mf => AppState.myFavorites.favoriteId == mf.id)
        // logger.log(deleteId, "delete id?")
        const res = await api.delete('api/favorites/' + gone.favoriteId)
        // logger.log(res.data, "deleted fav")
        AppState.favorites = AppState.favorites.filter(f => f.id != gone.id)
        AppState.myFavorites = AppState.myFavorites.filter(f => f.id != gone.id)
    }
}


export const recipesService = new RecipesService()