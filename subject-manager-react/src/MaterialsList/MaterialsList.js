import React from "react";
import "./MaterialsList.css";

import Material from "../Material/Material";
function MaterialsList(props) {
    return (
        <table className="app">
            <tr>
                <th>#</th>
                <th>Name</th>
                <th>Source</th>
                <th>Actions</th>
            </tr>
            {props.materials.map((material, index) => {
                return (
                    <Material material={material} index={index} sid={props.sid} />
                )
            })}
        </table>
    );



}

export default MaterialsList;