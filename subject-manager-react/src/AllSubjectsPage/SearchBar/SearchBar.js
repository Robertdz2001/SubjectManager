import React from "react";
import "./SearchBar.css";

function SearchBar(props) {



    const search = (e) => {
        e.preventDefault();
        let searchedSubjects = props.allSubjects.filter(s => s.name.includes(`${e.target.name.value}`));
        searchedSubjects = searchedSubjects.filter(s => s.shortName.includes(`${e.target.shortName.value}`));

        searchedSubjects = sort(searchedSubjects, e.target.sortSubjects.value);
        props.changeShowedSubjects(searchedSubjects);
    }

    const sort = (subjects, sortBy) => {
        switch (sortBy) {

            case "":
                return subjects;
            case "name":
                console.log(subjects.sort((a, b) => a.name > b.name ? 1 : -1));
                return subjects.sort((a, b) => a.name > b.name ? 1 : -1);
            case "shortName":
                return subjects.sort((a, b) => a.shortName > b.shortName ? 1 : -1);
            case "time":
                return subjects.sort((a, b) => a.time > b.time ? 1 : -1);
            case "roomNumber":
                return subjects.sort((a, b) => a.roomNumber > b.roomNumber ? 1 : -1);
            case "day":
                return subjects.sort((a, b) => a.dayOfWeek > b.dayOfWeek ? 1 : -1);
        }


    }

    return (
        <div className="subjects-search-bar">
            <form action="#" onSubmit={search}>
                <div className="search-bar-inputs">
                    <div className="search-name"> <input className="search" type="text" name="name" placeholder="Search by Name" defaultValue={""} /></div>
                    <div className="search-short-name"> <input className="search" type="text" name="shortName" placeholder="Search by ShortName" defaultValue={""} /></div>
                    <select className="sort" name="sortSubjects">
                        <option value="">Sort By..</option>
                        <option value="name">Name</option>
                        <option value="shortName">ShortName</option>
                        <option value="roomNumber">Room Number</option>
                        <option value="day">Day</option>
                        <option value="time">Time</option>
                    </select>

                    <div className="subjects-submit"> <input type="submit" id="subjects-submit" value="Search" /> </div>
                </div>
            </form>
        </div>
    );


}

export default SearchBar;