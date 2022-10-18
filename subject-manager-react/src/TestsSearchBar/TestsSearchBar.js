import React from "react";
import "./TestsSearchBar.css";


function TestsSearchBar(props) {


    const search = (e) => {
        e.preventDefault();
        let searchedTests = props.allTests.filter(s => s.name.includes(`${e.target.name.value}`));

        searchedTests = sort(searchedTests, e.target.sortTests.value);
        props.changeShowedTests(searchedTests);
    }

    const sort = (tests, sortBy) => {
        switch (sortBy) {

            case "":
                return tests;
            case "name":
                return tests.sort((a, b) => a.name > b.name ? 1 : -1);
            case "date":
                return tests.sort((a, b) => a.date > b.date ? 1 : -1);
        }


    }

    return (
        <div className="tests-search-bar">
            <form action="#" onSubmit={search}>
                <div className="search-bar-inputs">
                    <div className="search-name"> <input className="search" type="text" name="name" placeholder="Search by Name" defaultValue={""} /></div>
                    <select className="sort" name="sortTests">
                        <option value="">Sort By..</option>
                        <option value="name">Name</option>
                        <option value="date">Date</option>
                    </select>

                    <div className="tests-submit"> <input type="submit" id="tests-submit" value="Search" /> </div>
                </div>
            </form>

        </div>



    );
}




export default TestsSearchBar;

