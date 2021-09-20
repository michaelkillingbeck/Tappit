import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PeopleService } from "./people.service";
import { IPersonDetail } from "./persondetail";

@Component({
    templateUrl: './person-detail.component.html',
    styleUrls: ['./person-detail.component.css']
})

export class PersonDetailComponent implements OnInit {
    pageTitle: string = "View Person Details";
    person: IPersonDetail | undefined;

    constructor(private personService: PeopleService, 
                private route: ActivatedRoute,
                private router: Router) {}

    navigateBack(): void {
        this.router.navigate(['/people']);        
    }

    ngOnInit() : void {
        const id = Number(this.route.snapshot.paramMap.get('id'));

        this.personService.getPersonById(id).subscribe({
            next: person => {
                this.person = person;
                console.log(this.person);
                console.log(person);
            }
        })
    }
}