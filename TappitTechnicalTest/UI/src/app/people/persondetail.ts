import { IFavouriteSport } from "./favourite-sport";
import { IPerson } from "./person";

export interface IPersonDetail {
    favouriteSports: IFavouriteSport[];
    firstName: string;
    id: number;
    isAuthorised: boolean;
    isEnabled: boolean;
    isValid: boolean;
    lastName: string;
}