package CommunicationModels;

import java.util.Map;

import Models.Recipe;

/**
 * Created by Morten on 27-04-2015.
 */
public class RecipeWithExtraData {

    public Map<Recipe, ExtraData> ListOfRecipes;

    public RecipeWithExtraData(Map<Recipe, ExtraData> listOfRecipes) {
        ListOfRecipes = listOfRecipes;
    }

}
