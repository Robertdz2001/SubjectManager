import React from "react";
import "./AllSubjectsList.css";
import Subject from "../Subject/Subject";
function AllSubjectsList(props) {
    return (
        <table className="app">
            <tr>
                <th>#</th>
                <th>Name</th>
                <th>ShortName</th>
                <th>Platform URL</th>
                <th>Room Number</th>
                <th>Day</th>
                <th>Time</th>
                <th>Actions</th>
            </tr>
            {props.showedSubjects.map((subject, index) => {
                return (
                    <Subject subject={subject} index={index} />
                )
            })}
        </table>
    );



}

export default AllSubjectsList;