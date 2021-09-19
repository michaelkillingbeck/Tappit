import { IFavouriteSport } from "./favourite-sport";
import { IPerson } from "./person";

export interface IPersonDetail {
    favouriteSportsDetails: IFavouriteSport[];
    firstName: string;
    id: number;
    isAuthorised: boolean;
    isEnabled: boolean;
    isValid: boolean;
    lastName: string;
}