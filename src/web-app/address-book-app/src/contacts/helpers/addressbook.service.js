import { addressbookApi } from '../../api/addressbookApi';

export const postContact = async (contact) => {
    const {data} = await addressbookApi.post('', contact);
    return data;
};

export const putContact = async (id, contact) => {
    const { status } = await addressbookApi.put(`/${id}`, contact);

    if(status !== 204)
        return false;
    
    return true;
};

export const deleteContact = async (id) => {
    const {status} = await addressbookApi.delete(`/${id}`);

    if(status !== 204)
        return false;
    
    return true;
};

export const getContactsFilterd = async (contact) => {    
    contact = contact?? '';    
    contact = contact.toLowerCase().trim();
    const {data} = await addressbookApi.get(`?contact=${contact}`);
    return data;
};

export const getContactById = async (id) => {  
    try {
        const {data, status} = await addressbookApi.get(`/${id}`);
        
        if(status === 404)
            return null;            
        
        return data;
    }  catch (error) {
    }
};