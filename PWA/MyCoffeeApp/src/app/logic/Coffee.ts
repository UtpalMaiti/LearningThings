import { PlaceLocation } from "./PlaceLocation";
import { TastingRating } from "./TastingRating";

export class Coffee {
    type:string;
    rating:number;
    notes:string;
    testingRating:TastingRating
    constructor(public name:string,public place:string,public location:PlaceLocation) {
        
    }
}
