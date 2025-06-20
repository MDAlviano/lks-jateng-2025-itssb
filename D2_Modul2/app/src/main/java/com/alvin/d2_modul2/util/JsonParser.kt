package com.alvin.d2_modul2.util

import com.alvin.d2_modul2.model.Job
import org.json.JSONArray

class JsonParser {

    fun parseJobFromJson(jobs: MutableList<Job>, jsonArray: JSONArray) {
        for (i in 0 until jsonArray.length()) {
            val jsonObject = jsonArray.getJSONObject(i)
            try {
                val company = jsonObject.getJSONObject("company")
                jobs.add(
                    Job(
                        id = jsonObject.getInt("id"),
                        name = jsonObject.getString("name"),
                        companyName = company.getString("name"),
                        locationRegion = jsonObject.getString("locationRegion"),
                        locationType = jsonObject.getString("locationType"),
                        yearOfExperience = jsonObject.getString("yearOfExperience"),
                        quota = jsonObject.getInt("quota")
                    )
                )
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }
    }

}