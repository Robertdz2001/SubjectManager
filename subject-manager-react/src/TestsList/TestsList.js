import React from "react";
import Test from "../Test/Test";
function AllTestsList(props) {
    return (
        <table className="app">
            <tr>
                <th>#</th>
                <th>Name</th>
                <th>Date</th>
                <th>Actions</th>
            </tr>
            {props.showedTests.map((test, index) => {
                return (
                    <Test test={test} index={index} />
                )
            })}
        </table>
    );



}

export default AllTestsList;