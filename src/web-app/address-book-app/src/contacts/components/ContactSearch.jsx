import { useNavigate, useSearchParams } from "react-router-dom";
import { useEffect, useState } from "react";

export const ContactSearch = () => {
  const [ searchParams, setSearchParams ] = useSearchParams();
  const contactSearch = searchParams.get('search');
  
  const [query, setQuery] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    setQuery(contactSearch?? '');
  }, [contactSearch]);

  const onInputChange = ({target}) => {
    const {value} = target;
    setQuery(value);
    navigate(`/contacts?search=${value}`);
  }

  return (
    <>
      <input
        type="text"
        placeholder="Search a contact"
        className="form-control"
        name="query"
        autoComplete="off"
        value={query}
        onChange={onInputChange}
        />
    </>
  );
};
