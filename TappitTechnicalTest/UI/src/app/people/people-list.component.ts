import { Component, OnInit } from "@angular/core";
import { PeopleService } from "./people.service";
import { IPerson } from "./person";

@Component({
    templateUrl: "./people-list.component.html"
})

export class PeopleListComponent implements OnInit {
    pageTitle: string = "My Amazing Favourite American Sports App";
    people: IPerson[] = [];

    constructor(private personService: PeopleService) {}

    ngOnInit(): void {
        this.personService.getAllPeople().subscribe({
            next: people => this.people = people
        });
    }
}