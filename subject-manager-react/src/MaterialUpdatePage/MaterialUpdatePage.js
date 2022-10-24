import React, { useState } from "react";
import { useNavigate, useParams } from "react-router";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";
import { useEffect } from "react";


function MaterialUpdatePage(props) {
    const { sid, lid } = useParams();
    const navigate = useNavigate();
    const [material, setMaterial] = useState(false);


    const handleUpdateMaterial = async (e) => {
        navigate(`/subjects/${sid}/view`);
        const updatedMaterial = {
            name: e.target.name.value,
            source: e.target.source.value,
        }

        try {
            const res = await axios.put(`https://subjectmanager-api-app.azurewebsites.net/api/subjects/${sid}/learningMaterials/${lid}`, updatedMaterial, {
                headers: {
                    'Authorization': localStorage.getItem("token")
                }
            });
        } catch (e) {
            alert(e);
        }


    }

    const getOneMaterial = async () => {

        try {
            const res = await axios.get(`https://subjectmanager-api-app.azurewebsites.net/api/subjects/${sid}/learningMaterials/${lid}`,
                {
                    headers: {
                        'Authorization': localStorage.getItem("token")
                    }
                });
            return res.data;
        } catch (e) {
            alert(e);
        }

    }

    useEffect(() => {
        async function getOne() {

            const one = await getOneMaterial();
            setMaterial(one);
        }
        getOne()

    }, []);

    if (!material) return <div>Loading...</div>;

    return (

        <div className="add-page">
            <form action="#" onSubmit={handleUpdateMaterial}>
                <div className="add-inputs">
                    <input type="text" name="name" placeholder="Name" maxLength={30} required defaultValue={material.name} />
                    <input type="url" name="source" placeholder="Source" required defaultValue={material.source} />
                    <div className="add-buttons">
                        <Button variant="primary" type="submit" size="lg">Update</Button>
                        <Button variant="dark" size="lg" onClick={() => { navigate(`/subjects/${sid}/view`) }}>Back</Button>
                    </div>
                </div>
            </form>


        </div>
    );
}

export default MaterialUpdatePage;