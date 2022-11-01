import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router";
import axios from "axios";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import { url } from "../App/App";
const getOneMaterial = async (sid, lid) => {

    try {
        const res = await axios.get(`${url}/api/subjects/${sid}/learningMaterials/${lid}`, {
            headers: {
                'Authorization': localStorage.getItem("token")
            }
        })

        return res.data;

    }
    catch (e) {
        alert(e);
    }
}


function MaterialViewPage() {

    const { sid, lid } = useParams();
    const [material, setMaterial] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        async function getOne() {
            const one = await getOneMaterial(sid, lid);
            setMaterial(one);
        }
        getOne()
    }, []);

    if (!material) return <div>Loading...</div>;


    return (
        <div className="view-page glass-bg">
            <p>Name: {material.name}</p>
            <p>Source: <a href={material.source}>{material.source}</a></p>
            <Button id="add-button" variant="dark" size="lg" onClick={() => { navigate(`/subjects/${sid}/view`) }}>Back</Button>
        </div>



    );

}

export default MaterialViewPage;