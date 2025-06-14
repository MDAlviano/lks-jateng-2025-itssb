package com.alvin.d2_modul2.repository

import com.alvin.d2_modul2.http.HttpHandler
import com.alvin.d2_modul2.util.JsonParser

object JobRepository {

    private val jsonParser = JsonParser()

    fun applyJob(jobId: Int): String {
        return HttpHandler.postRequest(
            endpoint = "api/jobs/$jobId/apply"
        )
    }



}